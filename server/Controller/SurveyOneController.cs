using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Interface;
using server.Mappers;

namespace server.Controller
{
    [Route("/api/surveyOne")]
    [ApiController]
    public class SurveyOneController : ControllerBase
    {
        private readonly ISurveyOneRepository _surveyRepo;

        public SurveyOneController(ISurveyOneRepository surveyRepo)
        {
            _surveyRepo = surveyRepo;
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateSurveyOneDto surveyDto)
        {
            var surveyModel = surveyDto.ToSurveyOneCreateDto();

            await _surveyRepo.CreateAsync(surveyModel);

            return CreatedAtAction(nameof(GetById), new {Id = surveyModel.ID}, surveyModel.ToSurveyOneDisplayDto());

            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var surveyModel = await _surveyRepo.GetByIDAsync(id);

            if (surveyModel == null)
            {
                return NotFound();
            }

            return Ok(surveyModel.ToSurveyOneDisplayDto());

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var surveyModel = await _surveyRepo.DeleteAsync(id);

            if (surveyModel == null)
            {
                return NotFound();
            }

            return NoContent();

        }
        
    }
}