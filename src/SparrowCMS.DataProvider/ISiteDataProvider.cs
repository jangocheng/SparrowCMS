﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SparrowCMS.DataProvider
{
    public interface ISiteDataProvider
    {
        IEnumerable<Site> GetSites();
    }
}