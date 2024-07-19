using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos;
using server.Model;

namespace server.Mappers
{
    public static class SurveyOneMapper
    {
        public static SurveyOne ToSurveyOneCreateDto(this CreateSurveyOneDto surveyDto)
        {
            return new SurveyOne {
                Email = surveyDto.Email,
                Address = surveyDto.Address,
                County = surveyDto.County,
                State = surveyDto.State,
                ZipCode = surveyDto.ZipCode,
            };
        }

        public static DisplaySurveyDto ToSurveyOneDisplayDto (this SurveyOne surveyDto)
        {
            return new DisplaySurveyDto{
                ID = surveyDto.ID,
                Email = surveyDto.Email,
                Address = surveyDto.Address,
                County = surveyDto.County,
                State = surveyDto.State,
                ZipCode = surveyDto.ZipCode,

            };
        }
    }
}