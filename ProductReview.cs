using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement_Linq
{
    class ProductReview
    {
        public int ProductId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public double Rating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        /// <value>
        /// The review.
        /// </value>
        public string Review
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is like.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is like; otherwise, <c>false</c>.
        /// </value>
        public bool isLike
        {
            get;
            set;
        }
    }
}
