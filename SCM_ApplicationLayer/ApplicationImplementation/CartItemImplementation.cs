using System;
using System.Collections.Generic;
using System.Linq;
using SCM_DataLayer.DataEntity;
using SCM_DataLayer.DataRepositoryImplementation;

namespace SCM_ApplicationLayer.ApplicationImplementation
{
    public class CartItemImplementation
    {
        private readonly CartItemRepositoryImplementation CartItemRI = new CartItemRepositoryImplementation();

        public CartItemImplementation()
        {

        }

        public List<CartItem> GetCartItems(int ID = -1)
        {
            try
            {
                if (ID == -1 )
                {
                    return CartItemRI.GetAll().ToList();
                }
                else
                {
                    return CartItemRI.Get(c=>c.CartItemId ==ID).ToList();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void AddCartItem(CartItem cartItem)
        {
            try
            {
                CartItemRI.Add(cartItem);
                CartItemRI.Commit();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteCarItem(CartItem cartItem)
        {
            try
            {
                CartItemRI.Delete(c=> c == cartItem);
                CartItemRI.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCarItem(CartItem cartItem)
        {
            try
            {
                CartItemRI.Update(cartItem);
                CartItemRI.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CartItem  FindCartItem(int? id)
        {
            try
            {
               return CartItemRI.Find(id);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
