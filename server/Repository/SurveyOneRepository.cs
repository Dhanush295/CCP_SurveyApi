using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interface;
using server.Model;

namespace server.Repository
{
    public class SurveyOneRepository : ISurveyOneRepository
    {

        private readonly ApplicationDBContext _contex;

        public SurveyOneRepository(ApplicationDBContext contex)
        {
            _contex = contex;
            
        }
        
        public async Task<SurveyOne> CreateAsync(SurveyOne surveyModel)
        {
            await _contex.SureyOnes.AddAsync(surveyModel);
            await _contex.SaveChangesAsync();
            return surveyModel;
        }

        public async Task<SurveyOne?> DeleteAsync(int id)
        {
            var surveyModel = await _contex.SureyOnes.FirstOrDefaultAsync(x => x.ID == id);

            if (surveyModel == null)
            {
                return null;
            }

            _contex.SureyOnes.Remove(surveyModel);

            await _contex.SaveChangesAsync();

            return surveyModel;
        }

        public async Task<SurveyOne?> GetByIDAsync(int id)
        {
            var surveyModel = await _contex.SureyOnes.FindAsync(id);

            if (surveyModel == null)
            {
                return null;
            }

            return surveyModel;
        }
    }
}