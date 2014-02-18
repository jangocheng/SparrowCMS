﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace SparrowCMS.Core
{
    public class Document : DynamicObject
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var key = binder.Name;
            _data.TryGetValue(key, out result);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this[binder.Name] = value;
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _data.Keys;
        }

        public object this[string key]
        {
            get
            {
                return _data.ContainsKey(key) ? _data[key] : null;
            }
            set
            {
                if (_data.ContainsKey(key))
                    _data[key] = value;
                else
                    _data.Add(key, value);
            }
        }

    }

}
