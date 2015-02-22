﻿namespace SparrowCMS.Labels.Shared.Attributes
{
    public class MaxLength : FieldFunction
    {
        private int Length { get { return int.Parse(Value); } }

        public override string ConvertFieldValue(object fieldValue)
        {
            var result = base.ConvertFieldValue(fieldValue);

            var maxLength = 0;
            if (int.TryParse(Value, out maxLength) && result.Length > maxLength)
            {
                return result.Substring(0, Length) + "...";
            }

            return result;
        }
    }
}