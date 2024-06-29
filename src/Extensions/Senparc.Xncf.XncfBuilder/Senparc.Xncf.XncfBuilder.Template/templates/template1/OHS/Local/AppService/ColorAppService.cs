﻿using Senparc.CO2NET;
using Senparc.Ncf.Core.AppServices;
using ORGPLACEHOLDER.Xncf.MODPLACEHOLDER.Domain.Services;
using ORGPLACEHOLDER.Xncf.MODPLACEHOLDER.Models.DatabaseModel.Dto;
using ORGPLACEHOLDER.Xncf.MODPLACEHOLDER.OHS.Local.PL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORGPLACEHOLDER.Xncf.MODPLACEHOLDER.OHS.Local.AppService
{
    public class ColorAppService : AppServiceBase
    {
        private readonly ColorService _colorService;

        public ColorAppService(IServiceProvider serviceProvider, ColorService colorService) : base(serviceProvider)
        {
            this._colorService = colorService;
        }


        /// <summary>
        /// 获取或初始化一个 ColorDto 对象
        /// </summary>
        /// <returns></returns>
        public async Task<AppResponseBase<Color_GetOrInitColorResponse>> GetOrInitColorAsync()
        {
            return await this.GetResponseAsync<Color_GetOrInitColorResponse>(async (response, logger) =>
            {
                var dt1 = SystemTime.Now;//开始计时

                var colorDto = await _colorService.GetOrInitColor();//获取或初始化颜色参数

                var costMs = SystemTime.DiffTotalMS(dt1);//记录耗时

                Color_GetOrInitColorResponse result = new(colorDto.Red, colorDto.Green, colorDto.Blue, costMs);

                return result;
            });
        }
    }
}
