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
    public class EmployeeService : BaseService, IService<EmployeeDTO>
    {
        public bool Delete(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    uow.Employees.Delete(id);
                    return uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return false;
                }
            }

        }

        public EmployeeDTO Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.Employees.Get(id);

                var dto = Mapper.Map<Employee, EmployeeDTO>(entity);
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }

        }

        public List<EmployeeDTO> List()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var employees = uow.Employees.List();

                List<EmployeeDTO> employeeList = new List<EmployeeDTO>();

                foreach (var item in employees)
                {
                    EmployeeDTO employee = Mapper.Map<Employee, EmployeeDTO>(item);
                    employee.DepartmentName = item.Position.Department.DepartmentName;
                    employee.PositionName = item.Position.PositionName;
                    employee.RecordStatusName = item.RecordStatus.RecordStatusName;

                    employeeList.Add(employee);
                }

                return employeeList;
            }

        }

        public int Save(EmployeeDTO obj)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    Employee employee = Mapper.Map<EmployeeDTO, Employee>(obj);

                    employee.RecordStatusId = 1;
                    employee.CreatedDate = DateTime.Now;


                    var saved = uow.Employees.Save(employee);
                    uow.Commit();
                    return saved.EmployeeId;
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return 0;
                }

            }
        }
            public int Update(EmployeeDTO obj)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    Employee employee = Mapper.Map<EmployeeDTO, Employee>(obj);
                    employee.ModifiedDate = DateTime.Now;

                    uow.Employees.Update(employee);
                    uow.Commit();

                    return obj.EmployeeId;
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
