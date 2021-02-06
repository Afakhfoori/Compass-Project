using System;
using System.Collections.Generic;
using Compass.Domain;


namespace Compass.Service.Core
{
    public interface ISurveyService
    {
        public IEnumerable<Survey> GetAllItems();
        public Survey GetItemById(string id);
    }
}
