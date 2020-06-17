using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiDemo.Modals;
using RestApiDemo.Modals.Dtos;
using RestApiDemo.Repository.IRepository;
using System.Collections.Generic;

namespace RestApiDemo.Controllers
{
    [Route("api/trails")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "Trial")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TrailsController : Controller
    {
        private ITrialRepository _trailRepo;
        private readonly IMapper _mapper;
        public TrailsController(ITrialRepository trailRepo, IMapper mapper)
        {
            _trailRepo = trailRepo; _mapper = mapper;
        }
        /// <summary>
        /// get list of all national parks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TrialDto>))]
        public IActionResult GetTrials()
        {
            var objlist = _trailRepo.GetTrials();
            var objDto = new List<TrialDto>();

            foreach(var obj in objlist)
            {
                objDto.Add(_mapper.Map<TrialDto>(obj));
            }
            return Ok(objDto);
        }

        /// <summary>
        /// get national park using id
        /// </summary>
        /// <param name="id"> The id of national park </param>
        /// <returns></returns>
        [HttpGet("{id:int}",Name ="GetTrial")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrialDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTrial(int id)
        {
            var obj = _trailRepo.GetTrial(id);
            if( obj == null)
            {
                return NotFound(new { message="Invalid id" });
            }
            var objDto = _mapper.Map<TrialDto>(obj);

            return Ok(objDto);
        }
        /// <summary>
        /// post national park details
        /// </summary>
        /// <param name="trialDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TrialDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateTrial([FromBody] TrialCreateDto trialDto)
        {
            if( trialDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_trailRepo.TrialExist(trialDto.Name))
            {
                ModelState.AddModelError("", "National Park already exist!");
                return StatusCode(404, ModelState);
            }
            
            var trialObj = _mapper.Map<Trial>(trialDto);

            if(!_trailRepo.CreateTrial(trialObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record{trialObj.Name}");
                return StatusCode(500, ModelState);
            }
            //return Ok();
            return CreatedAtRoute("GetTrial", new { id = trialObj.Id }, trialObj);
        }

        /// <summary>
        /// Upate national park details
        /// </summary>
        /// <param name="id">supply id of park detail to update</param>
        /// <param name="trialDto"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}", Name = "UpdateTrial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTrial(int id, TrialUpdateDto trialDto)
        {
            if( trialDto == null || id != trialDto.Id)
            {
                return BadRequest(ModelState);
            }

            var trialObj = _mapper.Map<Trial>(trialDto);
            if (!_trailRepo.UpdateTrial(trialObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record{trialObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        /// <summary>
        /// delete national park detail
        /// </summary>
        /// <param name="id">supply id to delete detail</param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeleteTrial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTrial(int id)
        {
            if (!_trailRepo.TrialExist(id))
            {
                return NotFound();
            }

            var trialObj = _trailRepo.GetTrial(id);

            if (!_trailRepo.DeleteTrial(trialObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record{trialObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}