﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SparrowCMS.Base
{
    public interface ILabel : ITemplate
    {
        string Content { get; set; }
    }
}
