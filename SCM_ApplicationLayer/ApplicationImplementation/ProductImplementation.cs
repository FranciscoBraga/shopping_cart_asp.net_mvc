using SCM_DataLayer.DataRepositoryImplementation;
using SCM_DataLayer.DataEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SCM_ApplicationLayer.ApplicationImplementation
{
    public class ProductImplementation
    {

        private readonly ProductRepositoryImplementation ProductRI = new ProductRepositoryImplementation();

        public ProductImplementation()
        {

        }

        public List<Product> GetProduct(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return ProductRI.GetAll().ToList();
                }
                else
                {
                    return ProductRI.Get(p => p.Id == ID).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }

        public void AddProduct(Product product)
        {
            try
            {
                ProductRI.Add(product);
                ProductRI.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product Find(int? id)
        {
            try
            {
               return ProductRI.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveProduct(Product product)
        {
            try
            {
                ProductRI.Delete(p => p == product);
                ProductRI.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                ProductRI.Update(product);
                ProductRI.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
