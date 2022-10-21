﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FFS.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "FreshFoodStoreDb";
        public const string CartSession = "CartSession";
        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }
        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 8;
            public const int NumberOfLatestProducts = 8;
        }
        public class ProductConstants
        {
            public const string NA = "N/A";
        }
    }
}
