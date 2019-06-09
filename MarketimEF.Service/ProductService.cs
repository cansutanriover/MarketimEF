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
    public class ProductService : BaseService, IService<ProductDTO>
    {
        /*
* Arayüz ve Data layer arasında DTO nesneleri aracılığıyla veri taşınması ve businees logic işlevini görür.
*/

        public List<ProductDTO> List()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var products = uow.Products.List();

                //List<Product> -> List<ProductDTO>

                List<ProductDTO> productList = new List<ProductDTO>();

                foreach (var item in products)
                {
                    ProductDTO product = Mapper.Map<Product, ProductDTO>(item);
                    product.ProductName = item.ProductName;
                    product.CategoryName = item.Category.CategoryName;
                    product.SupplierName = item.Supplier.CompanyName;
                    product.UnitName = item.Unit.UnitName;
                    product.RecordStatusName = item.RecordStatus.RecordStatusName;
                    product.CreatedByName = item.CreatedBy != null ? item.Employee.FirstName + " " + item.Employee.LastName : "-";

                    productList.Add(product);
                }

                return productList;
            }
        }

        public int Save(ProductDTO productDTO)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    Product productEntity = Mapper.Map<ProductDTO, Product>(productDTO);

                    productEntity.RecordStatusId = 1;
                    productEntity.CreatedDate = DateTime.Now;


                    var saved = uow.Products.Save(productEntity);
                    uow.Commit();

                    return saved.ProductId;
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return 0;
                }
            }
        }

        public int Update(ProductDTO productDTO)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    Product productEntity = Mapper.Map<ProductDTO, Product>(productDTO);
                    productEntity.ModifiedDate = DateTime.Now;

                    uow.Products.Update(productEntity);
                    uow.Commit();

                    return productDTO.ProductId;
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return 0;
                }
            }
        }

        public bool Delete(int productId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    uow.Products.Delete(productId);
                    return uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return false;
                }
            }
        }

        public ProductDTO Get(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var entity = uow.Products.Get(id);

                var dto = Mapper.Map<Product, ProductDTO>(entity);
                dto.RecordStatusName = entity.RecordStatus.RecordStatusName;

                return dto;
            }

        }
    }
}
