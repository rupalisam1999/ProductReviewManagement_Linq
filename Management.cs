using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement_Linq
{
    public class Management
    {
        public void display(List<ProductReview> recordData)
        {
            foreach (var list in recordData)
            {
                Console.WriteLine("Product id = " + list.ProductId + "User id = " + list.UserId + "Rating is = " + list.Rating + " Review is = " + list.Review + " isLike = " + list.isLike);
            }
        }
        //UC-2 retrieve top three records order by rating
        public void topRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews orderby productReview.Rating descending select productReview).Take(3).ToList();
            Console.WriteLine("\n Top 3 records = ");
            display(recordData);
        }

        //uc3- Retrieve all records whos rating is grater than three

        public void selectedRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews where (productReview.ProductId == 1 || productReview.ProductId == 4 || productReview.ProductId == 9) && productReview.Rating > 3 select productReview).ToList();
            Console.WriteLine("\n Rating grater than 3 with product id 1,4,9 = ");
            display(recordData);
        }

        //UC4- Retrieves the count of record with  the help of group by id.

        public void retrieveCountOfRecords(List<ProductReview> listProductReviews)
        {
            var recordData = listProductReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            Console.WriteLine("\n Product id and count = ");
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + " = " + list.Count);
            }
        }
    }
}
