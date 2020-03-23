using System;
using System.Collections.Generic;
using System.Text;

namespace DTBlog.DataAccess.Interface
{
    /// <summary>
    /// UnitOfWork sınıfı tarafından kullanılacak arayüz.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
