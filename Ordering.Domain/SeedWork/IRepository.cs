using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Ordering.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
