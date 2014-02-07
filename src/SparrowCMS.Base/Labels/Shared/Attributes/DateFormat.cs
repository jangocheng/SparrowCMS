﻿using System;

namespace SparrowCMS.Base.Labels.Shared.Attributes
{
    public class DateFormat : FieldAttribute
    {
        public override string ConvertFieldValue(object fieldValue)
        {
            if (fieldValue is DateTime)
            {
                var dateFormat = Value;
                return ((DateTime)fieldValue).ToString(dateFormat);
            }
            return base.ConvertFieldValue(fieldValue);
        }

    }
}