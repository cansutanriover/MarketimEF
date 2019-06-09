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
    public class ShipperService : BaseService, IService<ShipperDTO>
    {
        public bool Delete(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    uow.Shippers.Delete(id);
                    return uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return false;
                }
            }
        }

        public ShipperDTO Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.Shippers.Get(id);

                var dto = Mapper.Map<Shipper, ShipperDTO>(entity);
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }

        }

        public List<ShipperDTO> List()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var shippers = uow.Shippers.List();

                if (shippers.Count > 0)
                {
                    List<ShipperDTO> shipperList = new List<ShipperDTO>();

                    foreach (var item in shippers)
                    {
                        ShipperDTO shipper = new ShipperDTO
                        {
                            ShipperId = item.ShipperId,
                            CompanyName = item.CompanyName,
                            Phone = item.Phone,
                            Email = item.Email,
                            RecordStatusName = item.RecordStatus.RecordStatusName,
                            CreatedByName = item.CreatedBy != null ? item.Employee.FirstName + " " + item.Employee.LastName : "-"
                        };


                        shipperList.Add(shipper);
                    }

                    return shipperList;
                }
                else
                {
                    return null;
                }
            }
        }

        public int Save(ShipperDTO shipperDTO)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {

                    Shipper shipper = Mapper.Map<ShipperDTO, Shipper>(shipperDTO);
                    shipper.CreatedDate = DateTime.Now;

                    var saved = uow.Shippers.Save(shipper);
                    uow.Commit();
                    return saved.ShipperId;

                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return 0;

                }

            }
        }

        public int Update(ShipperDTO shipperDTO)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {

                    Shipper shipper = Mapper.Map<ShipperDTO, Shipper>(shipperDTO);
                    shipper.ModifiedDate = DateTime.Now;

                    uow.Shippers.Update(shipper);
                    uow.Commit();
                    return shipperDTO.ShipperId;
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
