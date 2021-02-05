using System;
using System.Collections.Generic;
using System.Text;

namespace Compass.Domain
{
    public class Question
    {
        public Guid Id { get; set; }
        public string createdBy { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime createdDateTime { get; set; }
        public int questionType { get; set; }
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public List<Option> Options { get; set; }
    }
}
