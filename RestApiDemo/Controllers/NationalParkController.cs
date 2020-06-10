using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiDemo.Modals;
using RestApiDemo.Modals.Dtos;
using RestApiDemo.Repository.IRepository;

namespace RestApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class NationalParkController : Controller
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;
        public NationalParkController( INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo; _mapper = mapper;
        }
        /// <summary>
        /// get list of all national parks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NationalParkDto>))]
        public IActionResult GetNationalParks()
        {
            var objlist = _npRepo.GetNationalParks();
            var objDto = new List<NationalParkDto>();

            foreach(var obj in objlist)
            {
                objDto.Add(_mapper.Map<NationalParkDto>(obj));
            }
            return Ok(objDto);
        }

        /// <summary>
        /// get national park using id
        /// </summary>
        /// <param name="id"> The id of national park </param>
        /// <returns></returns>
        [HttpGet("{id:int}",Name ="GetNationalPark")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NationalParkDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetNationalPark(int id)
        {
            var obj = _npRepo.GetNationalPark(id);
            if( obj == null)
            {
                return NotFound(new { message="Invalid id" });
            }
            var objDto = _mapper.Map<NationalParkDto>(obj);

            return Ok(objDto);
        }
        /// <summary>
        /// post national park details
        /// </summary>
        /// <param name="nationalParkDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NationalParkDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if( nationalParkDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_npRepo.NationalParkExist(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park already exist!");
                return StatusCode(404, ModelState);
            }
            
            var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDto);

            if(!_npRepo.CreateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record{nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }
            //return Ok();
            return CreatedAtRoute("GetNationalPark", new { id = nationalParkObj.Id }, nationalParkObj);
        }

        /// <summary>
        /// Upate national park details
        /// </summary>
        /// <param name="id">supply id of park detail to update</param>
        /// <param name="nationalParkDto"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}", Name = "UpdateNationalPark")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateNationalPark(int id, NationalParkDto nationalParkDto)
        {
            if( nationalParkDto == null || id != nationalParkDto.Id)
            {
                return BadRequest(ModelState);
            }

            var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_npRepo.UpdateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record{nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        /// <summary>
        /// delete national park detail
        /// </summary>
        /// <param name="id">supply id to delete detail</param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeleteNationalPark")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteNationalPark(int id)
        {
            if (!_npRepo.NationalParkExist(id))
            {
                return NotFound();
            }

            var nationalParkObj = _npRepo.GetNationalPark(id);

            if (!_npRepo.DeleteNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record{nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}