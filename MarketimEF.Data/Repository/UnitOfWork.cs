using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.Data.Repository
{/// <summary>
/// Tek DBContext üzerinde çalışır ve transactional işlemleri yapmamızı sağlar.
/// Bir birim işi temsil eder.
/// </summary>
    public class UnitOfWork : IDisposable
    {
        private MarketimEntities db;
        private DbContextTransaction transaction;

        public UnitOfWork()
        {
            db = new MarketimEntities();
            //transaction = db.Database.BeginTransaction();

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Commit()
        {
            transaction = db.Database.BeginTransaction();

            int effected = db.SaveChanges();

            return effected > 0;
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        //?? eşitliğin solundaki değerin null olup olmadığını kontrol eder
        public Repository<Category> Categories { get { return new Repository<Category>(db); } }
        public Repository<City> Cities { get { return new Repository<City>(db); } }
        public Repository<Customer> Customers
        {
            get { return new Repository<Customer>(db); }
        }
        public Repository<Department> Departments { get { return new Repository<Department>(db); } }
        public Repository<Employee> Employees { get { return new Repository<Employee>(db); } }
        public Repository<Order> Orders { get { return  new Repository<Order>(db); } }
        public Repository<OrderDetail> OrderDetails { get { return  new Repository<OrderDetail>(db); } }
        public Repository<Position> Positions { get { return  new Repository<Position>(db); } }
        public Repository<Product> Products { get { return  new Repository<Product>(db); } }
        public Repository<RecordStatus> RecordStatuses { get { return  new Repository<RecordStatus>(db); } }
        public Repository<Shipper> Shippers { get { return  new Repository<Shipper>(db); } }
        public Repository<Supplier> Suppliers { get { return  new Repository<Supplier>(db); } }
        public Repository<Town> Towns { get { return  new Repository<Town>(db); } }
        public Repository<Unit> Units { get { return  new Repository<Unit>(db); } }
    }
}


