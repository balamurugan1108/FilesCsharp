﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ILogicLayer
    {
        public object JsonTOEXcel();
        public object ExcelToJson();
    }
}
