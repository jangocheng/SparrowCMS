﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SparrowCMS.Base
{
    public class Page : PageBase
    {
        public OutputCache OutputCache { get; set; }

        public UrlRoute UrlRoute { get; set; }
    }
}
