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
    public class DefinitionService:BaseService
    {
        public List<CityDTO> GetCities()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var cities = uow.Cities.List();

                List<CityDTO> cityList = new List<CityDTO>();

                foreach (var item in cities)
                {
                    CityDTO city = Mapper.Map<City, CityDTO>(item);

                    cityList.Add(city);
                }

                return cityList; 
            }
        }

        public List<TownDTO> GetTown(int cityId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var towns = uow.Towns.List();

                List<TownDTO> townList = new List<TownDTO>();

                foreach (var item in towns)
                {
                    TownDTO town = Mapper.Map<Town, TownDTO>(item);
                    town.CityName = item.City.CityName;

                    townList.Add(town);
                }

                return townList;
            }
        }

        public List<DepartmentDTO> GetDepartment()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var departments = uow.Departments.List();

                List<DepartmentDTO> departmentList = new List<DepartmentDTO>();

                foreach (var item in departments)
                {
                    DepartmentDTO department = Mapper.Map<Department, DepartmentDTO>(item);

                    departmentList.Add(department);
                }

                return departmentList;
            }
        }

        public List<PositionDTO> GetPositions()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var positions = uow.Positions.List();

                List<PositionDTO> positionList = new List<PositionDTO>();

                foreach (var item in positions)
                {
                    PositionDTO position = Mapper.Map<Position, PositionDTO>(item);

                    positionList.Add(position);
                }

                return positionList;
            }
        }
        public List<UnitDTO> GetUnits()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var units = uow.Units.List();

                List<UnitDTO> unitList = new List<UnitDTO>();

                foreach (var item in units)
                {
                    UnitDTO unit = Mapper.Map<Unit, UnitDTO>(item);

                    unitList.Add(unit);
                }

                return unitList;
            }
        }





        }
    }
