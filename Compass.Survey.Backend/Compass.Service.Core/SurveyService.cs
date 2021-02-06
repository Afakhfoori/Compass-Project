using System;
using System.Collections.Generic;
using System.Text;
using Compass.Repository.Core;
using Compass.Domain;
using System.Linq;

namespace Compass.Service.Core
{
    public class SurveyService: ISurveyService
    {
        private readonly Repository<Survey> _repo;
        public SurveyService()
        {
            var context = CompassContext.Instance;
            _repo = new SurveyRepository(context);
        }

        public IEnumerable<Survey> GetAllItems()
        {
            var surveyList = _repo.GetAll();
            return surveyList;
        }

        public Survey GetItemById(string id)
        {
            var result = _repo.GetSingle(s => s.Id == new Guid(id));

            return result;
        }

    }
}
