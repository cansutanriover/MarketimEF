using MarketimEF.Data;
using MarketimEF.Data.Repository;
using MarketimEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.Service
{
    public class CustomerService :BaseService, IService<CustomerDTO>
    {


        public bool Delete(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                try
                {
                    uow.Customers.Delete(id);
                    return uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return false;
                }
            }
        }

        public CustomerDTO Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.Customers.Get(id);

                var dto = Mapper.Map<Customer, CustomerDTO>(entity);
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }
        }

        public List<CustomerDTO> List()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var customers=uow.Customers.List();

                List<CustomerDTO> customerList = new List<CustomerDTO>();

                foreach (var item in customers)
                {
                    CustomerDTO customer = Mapper.Map<Customer, CustomerDTO>(item);
                    customer.CityName = item.Town.City.CityName;
                    customer.TownName = item.Town.TownName;
                    customer.RecordStatusName = item.RecordStatus.RecordStatusName;

                    customerList.Add(customer);
                }

                return customerList;
            }
        }

        public int Save(CustomerDTO obj)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    Customer customer = Mapper.Map<CustomerDTO, Customer>(obj);
                    customer.CreatedDate = DateTime.Now;
                    customer.RecordStatusId = 1;

                    var saved=uow.Customers.Save(customer);

                    return saved.CustomerId;
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return 0;
                }
            }
        }



        public int Update(CustomerDTO obj)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    Customer customer = Mapper.Map<CustomerDTO, Customer>(obj);
                    customer.ModifiedDate = DateTime.Now;

                    uow.Customers.Update(customer);
                    uow.Commit();
                    return obj.CustomerId;

                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return 0;
                }
            }

        }
    }
}
