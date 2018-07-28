using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DILifeTimeDemo.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DILifeTimeDemo.Controllers
{
    public class LifeTimeController : Controller
    {
        private readonly IGuidTransientService _guidTransientService;
        private readonly IGuidScopedService _guidScopedService;
        private readonly IGuidSingletonService _guidSingletonService;

        /// <summary>
        /// 通过构造函数进行注入
        /// </summary>
        /// <param name="guidTransientService"></param>
        /// <param name="guidScopedService"></param>
        /// <param name="guidSingletonService"></param>
        public LifeTimeController(IGuidTransientService guidTransientService,IGuidScopedService guidScopedService, IGuidSingletonService guidSingletonService)
        {
            _guidTransientService = guidTransientService;
            _guidScopedService = guidScopedService;
            _guidSingletonService = guidSingletonService;
        }

        public IActionResult Index()
        {
            ViewBag.TransientItem = _guidTransientService.GetGuid();
            ViewBag.ScopedItem = _guidScopedService.GetGuid();
            ViewBag.SingletonItem = _guidSingletonService.GetGuid();
            return View();
        }
    }
}