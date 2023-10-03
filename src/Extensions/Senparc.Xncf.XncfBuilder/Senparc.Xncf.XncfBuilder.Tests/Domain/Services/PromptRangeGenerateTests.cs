﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Senparc.Xncf.PromptRange.Tests;
using Senparc.Xncf.XncfBuilder.Domain;
using Senparc.Xncf.XncfBuilder.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senparc.Xncf.XncfBuilder.Tests.Domain.Services
{
    /// <summary>
    /// PromptRange 模块的初始化代码
    /// <para>注意：这会直接修改现有代码！</para>
    /// </summary>
    [TestClass]
    public class PromptRangeGenerateTests : XncfBuilderTestBase
    {
        protected PromptBuilderService _service;

        public PromptRangeGenerateTests()
        {
            _service = base._serviceProvder.GetRequiredService<PromptBuilderService>();
        }

        [TestMethod()]
        public async Task RunPromptTest()
        {
            var input = "这个领域用于控制所有的 Prompt 核心业务逻辑，包括使用 Prompt 操作大预言模型所需的所有必要的参数，类名叫：PromptGroup，用于管理一组相关联的 Prompt，并统一配置其参数。其中必须要包含 LLM 被调用时的所需的所有参数，包括但不仅限于： MaxToken、Temperature、TopP、FrequencyPenalty、ResultsPerPrompt、StopSequences、ChatSystemPrompt、TokenSelectionBiases，等等，除此以外，还需要包含用于评估 Prompt 效果所需要的必要参数，以及 Name 等属于“Group”类型的实体类应该有的参数。";

            var projectPath = Path.Combine("Y:\\Senparc 项目\\NeuCharFramework\\NcfPackageSources\\src\\Extensions\\Senparc.Xncf.PromptRange\\", "Domain", "Models", "DatabaseModel");

            //Directory.Delete(projectPath, true);

            CO2NET.Helpers.FileHelper.TryCreateDirectory(projectPath);

            var result = await _service.RunPromptAsync(PromptBuildType.EntityClass, input, projectPath);

            Assert.IsTrue(result.Contains("保存文件"));
            await Console.Out.WriteLineAsync(result);

            Assert.IsTrue(File.Exists(Path.Combine(projectPath, "PromptGroup.cs")));
            Assert.IsTrue(File.Exists(Path.Combine(projectPath, "Dto/PromptGroupDto.cs")));

            var senparcEntitiesFile = Path.Combine(projectPath, "PromptRangeSenparcEntities.cs");
            Assert.IsTrue(File.Exists(senparcEntitiesFile));

          var newContent = File.ReadAllText(senparcEntitiesFile);
            Assert.IsTrue(newContent.Contains("public PromptGroup PromptGroups { get; private set; }"));
        }
    }
}
