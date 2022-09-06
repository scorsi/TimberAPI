﻿using Bindito.Core;
using TimberApi.New.AssetSystem;
using TimberApi.New.ConfiguratorSystem;
using TimberApi.New.ResourceAssetSystem;
using TimberApi.New.SceneSystem;
using TimberApi.New.SpecificationSystem;
using TimberApi.New.SpecificationSystem.CustomSpecifications.Golems;

namespace TimberApi.New
{
    internal static class BootstrapConfigurator
    {
        public static void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<TimberApiInternal>().AsSingleton();
            containerDefinition.Bind<SceneListener>().AsSingleton();
            containerDefinition.Install(new ConfiguratorSystemConfigurator());
            containerDefinition.Install(new AssetSystemGlobalConfigurator());
            containerDefinition.Install(new SpecificationGlobalConfigurator());
            containerDefinition.Install(new GolemFactionPatchConfigurator());
            containerDefinition.Install(new ResourceAssetSystemConfigurator());
        }
    }
}
