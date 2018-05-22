
namespace NDC.SOAP
{
    using DevTrends.WCFDataAnnotations;
    using System;
    using System.Linq;
    using Models;
    using Infrastructure;
    using NCD.Infrastructure;
    using System.Threading.Tasks;
    using System.Data.Entity;
    /// <summary>
    ///  NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    ///  In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    /// </summary>
    [ValidateDataAnnotationsBehavior]
    public class PersonService : IPersonService
    {
        /// <summary>
        /// db instance
        /// </summary>
        private readonly ApplicationDbContext _db;
        private readonly EmailSender _sender;

        /// <summary>
        /// ctor
        /// </summary>
        public PersonService()
        {
            _db = new ApplicationDbContext();
            _sender = new EmailSender();
        }

        /// <summary>
        /// search by person creterias:names,gender,country,age,heigth and weight
        /// </summary>
        /// <param name="model">result count</param>
        /// <returns></returns>
        public async Task<int> Search(SearchModel model)
        {
            //names,gender and country
            var query = _db.People.Where(w => w.FullName.Contains(model.Names) || w.Gender.Equals(model.Sex) || w.Country.Contains(model.Nationality));

            //age
            if (model.MinAge <= model.MaxAge)
            {
                query = query.Where(w => DateTime.Now.Year - w.BirthDate.Year >= model.MinAge && DateTime.Now.Year - w.BirthDate.Year <= model.MaxAge);
            }
            else
            {
                throw new ArgumentException("Min Age <= Max Age");
            }

            //heigth
            if (model.MinHeigth <= model.MaxHeigth)
            {
                query = query.Where(w => w.Height >= model.MinAge && w.Height <= model.MaxHeigth);
            }
            else
            {
                throw new ArgumentException("Min Height <= Max Height");
            }

            //weight
            if (model.MinWeight <= model.MaxWeight)
            {
                query = query.Where(w => w.Weight >= model.MinWeight && w.Weight <= model.MaxWeight);
            }
            else
            {
                throw new ArgumentException("Min Weight <= Max Weight");
            }

            if (!query.Any())
            {
                throw new NullReferenceException("Not found result(s)");
            }
            else
            {
                var people = await query.ToArrayAsync();

                await _sender.BatchSendAsync(model.DestinationEmail, people);

                return query.Count();
            }
        }
    }
}
