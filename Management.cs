using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement_Linq
{
    public class Management
    {
        private readonly DataTable dataTable = new DataTable();
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
            //use linq operators group by and count
            var recordData = listProductReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() }); 
            Console.WriteLine("\n Product id and count = ");
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + " = " + list.Count);
            }
        }

        //UC5- Retrieves the productd and review.
        public void retrieveProductdAndReview(List<ProductReview> listProductReviews)
        {
            var recordData = listProductReviews.Select(x => new { ProductId = x.ProductId, Review = x.Review });
            Console.WriteLine("\n Product id and review = ");
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + "----------" + list.Review);
            }
        }
        //UC6- skip 5 records from list
        public void skipTopFiveRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews select productReview).Skip(5).ToList();
            Console.WriteLine("\n Top 5 records from list = ");
            display(recordData);
        }

        //UC7- Add extra rows in datatable

        public DataTable createTable(List<ProductReview> listProductReviews)
        {
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("UserId");
            dataTable.Columns.Add("Rating");
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike");
            return dataTable;
        }
     
        ////UC8- Retrieve records from list whos isLike value is true.
        //public void RetrieveRecordsWithIsLikeTrue(DataTable table)
        //{
        //    var recordData = from productReview in table.AsEnumerable() where (productReview.Field<bool>("isLike") == true) select productReview;
        //    Console.WriteLine("Records with is like true = ");
        //    foreach (var lists in recordData)
        //    {
        //        Console.WriteLine("Product id = " + lists.Field<int>("ProductId") + "User id = " + lists.Field<int>("UserId") + "Rating is = " + lists.Field<double>("Rating") + " Review is = " + lists.Field<string>("Review") + " isLike = " + lists.Field<bool>("isLike"));
        //    }
        //}

        //UC9- Finds the avrage rating.

        public void findAvrageRating(List<ProductReview> listProductReviews)
        {
            var recordData = listProductReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Average = x.Average(y => y.Rating) });
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + "----------" + list.Average);
            }
        }
    }
}
