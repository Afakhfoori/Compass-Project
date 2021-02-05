using System;
using System.Collections.Generic;
using System.Text;

namespace Compass.Domain
{
    public class Survey
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
