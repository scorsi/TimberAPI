﻿using System;
using System.Collections.Generic;
using TimberApi.Common.ConsoleSystem;
using TimberApi.New.ConfigSystem;
using UnityEngine;

namespace TimberApi.Core.ConfigSystem
{
    internal class ConfigService : IConfigService
    {
        private readonly string _consoleTag;

        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ConfigRepository _configRepository;

        public ConfigService(IInternalConsoleWriter consoleWriter, IEnumerable<IConfig> configs, string consoleTag)
        {
            _consoleWriter = consoleWriter;
            _consoleTag = consoleTag;
            _configRepository = ConfigRepository.CreateRepository(configs);
        }

        public T Get<T>() where T : IConfig, new()
        {
            try
            {
                return _configRepository.GetConfig<T>();
            }
            catch (Exception e)
            {
                _consoleWriter.LogAs(_consoleTag,  "Failed to retrieve config, returning default", LogType.Warning);
                _consoleWriter.LogAs(_consoleTag, "Failed config reason: " + e.Message, LogType.Error);
                return new T();
            }
        }
    }
}