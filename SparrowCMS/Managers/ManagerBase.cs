﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SparrowCMS.Managers
{
    public class ManagerBase
    {
        protected readonly CoreManager Core = CoreManager.GetInstance();
    }
}
