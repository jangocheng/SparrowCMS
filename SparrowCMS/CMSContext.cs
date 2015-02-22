﻿using SparrowCMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using SparrowCMS.Managers;
using SparrowCMS.Exceptions;

namespace SparrowCMS
{
    public class CMSContext
    {
        public Site Site { get; set; }

        public Page Page { get; set; }

        public NameValueCollection RouteData { get; set; }

        public Document ViewData { get; set; }

        public HttpContext HttpContext { get; set; }

        public static CMSContext Current = new CMSContext();

        public CoreManager Core { get; private set; }

        private CMSContext()
        {
            Core = CoreManager.GetInstance();
        }

        public void Init(HttpContext context)
        {
            //HttpContext
            Current.HttpContext = context;
            //匹配当前求情的站点
            Current.Site = Core.SiteManager.GetSite(context.Request.Url.Host);
            if (Current.Site == null)
            {
                throw new SiteNotFoundException();
            }
            //匹配当前请求的页面
            var page = Core.PageManager.GetPage(Current.Site, context.Request.Url.AbsolutePath);
            if (page == null)
            {
                throw new PageNotFoundException();
            }
            //页面初始化工作
            //page.Init(Current);
            //赋值给Context
            Current.Page = page;
            //获取RouteData
            RouteData = page.UrlRoute.GetRouteData(context);
        }

        //public IEnumerable<string> GetRequestAllKeys()
        //{
        //    return HttpContext.Request.QueryString.AllKeys.Select(e => e.ToLower()).Concat(HttpContext.Request.Form.AllKeys.Select(e => e.ToLower()));
        //}

        //public string GetPostData()
        //{
        //    using (var sr = new StreamReader(HttpContext.Request.InputStream))
        //    {
        //        return sr.ReadToEnd();
        //    }
        //}

        //public string Request(string key)
        //{
        //    return Current.RouteData[key];
        //}

        internal IFactory GetFactory(string pluginName = null)
        {
            return Core.FactoryManager.GetFactory(pluginName);
        }
    }
}