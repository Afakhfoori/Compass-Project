using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Compass.Domain;
using Compass.Repository;
using Microsoft.EntityFrameworkCore;

namespace Compass.Repository.Core
{
    public class SurveyRepository : Repository<Survey>
    {
        public SurveyRepository(CompassContext context) : base(context) { }
        public override IEnumerable<Survey> GetAll(params Expression<Func<Survey, object>>[] navigationProperties)
        {
            _dbQuery = _dbQuery.Include(i => i.Questions).ThenInclude(it => it.Options);

            return _dbQuery
               .AsNoTracking()
               .ToList<Survey>();
        }

        public override Survey GetSingle(Expression<Func<Survey, bool>> where, params Expression<Func<Survey, object>>[] navigationProperties)
        {
            var survey = _dbQuery.Include(i => i.Questions).ThenInclude(it => it.Options).SingleOrDefault(where);
            return survey;
        }
    }

}
