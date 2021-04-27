using ChangeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Repositories
{
    public class BaseRepository <T> where T : ModelDb
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
    }
}
