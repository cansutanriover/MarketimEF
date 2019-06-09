using MarketimEF.Data;
using MarketimEF.Data.Repository;
using MarketimEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.Service
{
    public class SupplierService : BaseService, IService<SupplierDTO>
    {
        public List<SupplierDTO> List()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var result = uow.Suppliers.List();

                if (result.Count > 0)
                {
                    List<SupplierDTO> suppliers = new List<SupplierDTO>();

                    foreach (var item in result)
                    {
                        SupplierDTO supplier = new SupplierDTO
                        {
                            SupplierId = item.SupplierId,
                            CompanyName = item.CompanyName,
                            Phone = item.Phone,
                            Email = item.Email,
                            RecordStatusName = item.RecordStatus.RecordStatusName,
                            CreatedByName = item.CreatedBy != null ? item.Employee.FirstName + " " + item.Employee.LastName : "-"
                        };

                        suppliers.Add(supplier);
                    }

                    return suppliers;
                }
                else
                {
                    return null;
                }
            }
        }

        public int Save(SupplierDTO supplierDTO)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    Supplier supplier = Mapper.Map<SupplierDTO, Supplier>(supplierDTO);
                    supplier.CreatedDate = DateTime.Now;

                    

                    var saved=uow.Suppliers.Save(supplier);
                    uow.Commit();
                    return saved.SupplierId;
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return 0;
                }
            }
        }

        public int Update(SupplierDTO supplierDTO)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    Supplier supplier = Mapper.Map<SupplierDTO, Supplier>(supplierDTO); 
                    supplier.ModifiedDate = DateTime.Now;

                    uow.Suppliers.Update(supplier);
                    uow.Commit();
                    return supplierDTO.SupplierId;
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return 0;
                }
            }
        }

        public bool Delete(int supplierId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    uow.Suppliers.Delete(supplierId);
                    return uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return false;
                }
            }
        }

        public SupplierDTO Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.Suppliers.Get(id);

                var dto = Mapper.Map<Supplier, SupplierDTO>(entity);
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }

        }
    }
}
