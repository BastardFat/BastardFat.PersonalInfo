﻿using System.Data.Entity;
using System.Threading.Tasks;

namespace BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Interfaces
{
    public interface IUnitOfWork<out TDbContext> where TDbContext : DbContext
    {
        void Commit();
        Task CommitAsync();
    }
}