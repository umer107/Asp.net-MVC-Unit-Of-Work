using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Infrastructure
{
    public class DataOperations
    {
        // this is default branch
        public Work Work { get; set; }

        protected WebApiDbEntities db { get; set; }

        protected WebApiDbEntities dbs { get; set; }

        public DataOperations(WebApiDbEntities dbContext, Work work)
        {
            db = dbContext;
            this.Work = work;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        protected void Create<T>(T entity) where T : class
        {
            var newEntry = db.Set<T>().Add(entity);
            //db.SaveChanges();
        }

        protected void Create<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                db.Set<T>().Add(entity);
            }
            //db.SaveChanges();
        }

        protected IQueryable<T> Read<T>() where T : class
        {
            return db.Set<T>().AsQueryable<T>();
        }

        protected DbSet<T> ReadAsDBSet<T>() where T : class
        {
            return db.Set<T>();
        }

        protected void Update<T>(T entity) where T : class
        {
            var entry = db.Entry(entity);
            db.Set<T>().Attach(entity);
            entry.State = EntityState.Modified;
            //db.SaveChanges();
        }

        protected void Delete<T>(T entity) where T : class
        {
            db.Set<T>().Remove(entity);
            //db.SaveChanges();
        }

        protected void Delete<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                db.Set<T>().Remove(entity);
            }
            //db.SaveChanges();
        }

   

        protected int RunSQlCommand(string command)
        {
            return this.db.Database.ExecuteSqlCommand(command);
        }

      
        public IEnumerable<TEntity> ExecuteStoredProcedure<TEntity>(string query, SqlParameter[] parameters)
            where TEntity : class
        {
            IEnumerable<TEntity> Results = null;
            Results = db.Database.SqlQuery<TEntity>(query, parameters).ToList();
            return Results;
        }

        //protected void BulkDeleteWithExists(string tableName, string primaryKey, List<int> ids)
        //{
        //    var totalCount = ids.Count;
        //    if (totalCount == 0)
        //    {
        //        return;
        //    }

        //    var chunks = BulkHelper.CreateChunksOfIds(ids, 2000);

        //    foreach (var key in chunks.Keys)
        //    {
        //        var thisChunk = chunks[key];
        //        var countChunk = thisChunk.Count;
        //        var sb = new StringBuilder();
        //        sb.Append("Delete from ");
        //        sb.Append(tableName);
        //        sb.Append(" Where ");
        //        sb.Append(primaryKey);
        //        sb.Append(" EXISTS (");

        //        string ListArray = "";

        //        for (int i = 0; i < countChunk; i++)
        //        {
        //            if (i > 0)
        //            {
        //                ListArray += ",";
        //            }
        //            ListArray += thisChunk[i];
        //        }

        //        string subQuery = string.Format(" Select From {0} where {1} IN ( {2} ) ", tableName, primaryKey, ListArray);
        //        sb.Append(subQuery);
        //        sb.Append(")");

        //        db.Database.ExecuteSqlCommand(sb.ToString());
        //    }
        //}

        protected void ExecuteCommand(string command, params object[] parameters)
        {
            db.Database.ExecuteSqlCommand(command, parameters);
        }

        protected void ExecuteCommandAsync(string command, params object[] parameters)
        {

        }

        //protected TransactionScope CreateTransaction()
        //{
        //    return new TransactionScope();
        //}

        protected void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);

                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }

        }

        protected void TestSaveChanges()
        {
            db.SaveChanges();
        }

        protected void SaveChangesWithoutTryCatch()
        {
            db.SaveChanges();
        }


  



   

    }
}
