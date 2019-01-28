using System;
using System.Collections.Generic;
using System.Linq;
using SCM_DataLayer.DataEntity;
using SCM_DataLayer.DataRepositoryImplementation;

namespace SCM_ApplicationLayer.ApplicationImplementation
{
    public class CartImplementation
    {

        private readonly CartRepositoryImplementation CartRI = new CartRepositoryImplementation();

        public CartImplementation()
        {

        }

        public List<Cart> GetCart(int ID = -1)
        {
            try
            {
                if (ID == -1)
                {
                    return CartRI.GetAll().ToList();
                }
                else
                {
                    return CartRI.Get(c => c.Id == ID).ToList();
                }
            }
            catch (Exception  ex)
            {
                throw ex;
            }
        }

        public void AddCart(Cart cart)
        {
            try
            {
                CartRI.Add(cart);
                CartRI.Commit();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DelelteCart(Cart cart)
        {
            try
            {
                CartRI.Delete(c=>c==cart);
                CartRI.Commit();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateCart(Cart cart)
        {
            try
            {
                CartRI.Update(cart);
                CartRI.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Cart FindCart(int? id)
        {
            try
            {
               return CartRI.Find(id);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

     
    }
}
