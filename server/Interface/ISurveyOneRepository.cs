using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Model;

namespace server.Interface
{
    public interface ISurveyOneRepository
    {
        Task<SurveyOne> CreateAsync(SurveyOne surveyModel);

        Task<SurveyOne?> GetByIDAsync(int id);

        Task<SurveyOne?> DeleteAsync( int id);

        
    }
}