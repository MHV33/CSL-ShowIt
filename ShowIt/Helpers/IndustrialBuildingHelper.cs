﻿using ColossalFramework;
using UnityEngine;

namespace ShowIt
{
    public static class IndustrialBuildingHelper
    {
        public static int CalculateResourceEffect(ushort buildingID, ref Building data, ImmaterialResourceManager.Resource resource)
        {
            int value;

            switch (resource)
            {
                case ImmaterialResourceManager.Resource.HealthCare:
                case ImmaterialResourceManager.Resource.FireDepartment:
                case ImmaterialResourceManager.Resource.PoliceDepartment:
                case ImmaterialResourceManager.Resource.EducationElementary:
                case ImmaterialResourceManager.Resource.EducationHighSchool:
                case ImmaterialResourceManager.Resource.EducationUniversity:
                case ImmaterialResourceManager.Resource.DeathCare:
                case ImmaterialResourceManager.Resource.PublicTransport:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 100, 500, 50, 100);
                case ImmaterialResourceManager.Resource.NoisePollution:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 10, 100, 0, 100);
                case ImmaterialResourceManager.Resource.CrimeRate:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 10, 100, 0, 100);
                case ImmaterialResourceManager.Resource.Health:
                case ImmaterialResourceManager.Resource.Wellbeing:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 60, 100, 0, 50);
                case ImmaterialResourceManager.Resource.Density:
                    return 0;
                case ImmaterialResourceManager.Resource.Entertainment:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 100, 500, 50, 100);
                case ImmaterialResourceManager.Resource.LandValue:
                case ImmaterialResourceManager.Resource.Attractiveness:
                case ImmaterialResourceManager.Resource.Coverage:
                    return 0;
                case ImmaterialResourceManager.Resource.FireHazard:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 50, 100, 10, 50);
                case ImmaterialResourceManager.Resource.Abandonment:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 15, 50, 10, 20);
                case ImmaterialResourceManager.Resource.CargoTransport:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 100, 500, 50, 100);
                case ImmaterialResourceManager.Resource.RadioCoverage:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 50, 100, 20, 25);
                case ImmaterialResourceManager.Resource.FirewatchCoverage:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 100, 1000, 0, 25);
                case ImmaterialResourceManager.Resource.EarthquakeCoverage:
                    return 0;
                case ImmaterialResourceManager.Resource.DisasterCoverage:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 50, 100, 20, 25);
                case ImmaterialResourceManager.Resource.TourCoverage:
                    return 0;
                case ImmaterialResourceManager.Resource.PostService:
                    Singleton<ImmaterialResourceManager>.instance.CheckLocalResource(resource, data.m_position, out value);
                    return ImmaterialResourceManager.CalculateResourceEffect(value, 100, 500, 50, 100);
                case ImmaterialResourceManager.Resource.None:
                    return 0;
                default:
                    return 0;
            }
        }

        public static int CalculateResourceEffect(ushort buildingID, ref Building data, ZonedBuildingExtenderPanel.LevelUpResource resource)
        {
            int education = 0;
            int services = 0;
            if (data.m_levelUpProgress > 0)
            {
                education = (data.m_levelUpProgress & 0xF);
                services = (data.m_levelUpProgress >> 4);
            }
            Debug.Log("progress: " + data.m_levelUpProgress + ", ed: " + education + ", s: " + services);
            switch (resource)
            {
                case ZonedBuildingExtenderPanel.LevelUpResource.Education:
                    return education;
                case ZonedBuildingExtenderPanel.LevelUpResource.Services:
                    return services;
                default:
                    return 0;
            }
        }

        public static int GetMaxEffect(ImmaterialResourceManager.Resource resource)
        {
            switch (resource)
            {
                case ImmaterialResourceManager.Resource.HealthCare:
                case ImmaterialResourceManager.Resource.FireDepartment:
                case ImmaterialResourceManager.Resource.PoliceDepartment:
                case ImmaterialResourceManager.Resource.EducationElementary:
                case ImmaterialResourceManager.Resource.EducationHighSchool:
                case ImmaterialResourceManager.Resource.EducationUniversity:
                case ImmaterialResourceManager.Resource.DeathCare:
                case ImmaterialResourceManager.Resource.PublicTransport:
                    return 100;
                case ImmaterialResourceManager.Resource.NoisePollution:
                    return 100;
                case ImmaterialResourceManager.Resource.CrimeRate:
                    return 100;
                case ImmaterialResourceManager.Resource.Health:
                case ImmaterialResourceManager.Resource.Wellbeing:
                    return 50;
                case ImmaterialResourceManager.Resource.Density:
                    return 0;
                case ImmaterialResourceManager.Resource.Entertainment:
                    return 100;
                case ImmaterialResourceManager.Resource.LandValue:
                case ImmaterialResourceManager.Resource.Attractiveness:
                case ImmaterialResourceManager.Resource.Coverage:
                    return 0;
                case ImmaterialResourceManager.Resource.FireHazard:
                    return 50;
                case ImmaterialResourceManager.Resource.Abandonment:
                    return 20;
                case ImmaterialResourceManager.Resource.CargoTransport:
                    return 100;
                case ImmaterialResourceManager.Resource.RadioCoverage:
                    return 25;
                case ImmaterialResourceManager.Resource.FirewatchCoverage:
                    return 25;
                case ImmaterialResourceManager.Resource.EarthquakeCoverage:
                    return 0;
                case ImmaterialResourceManager.Resource.DisasterCoverage:
                    return 25;
                case ImmaterialResourceManager.Resource.TourCoverage:
                    return 0;
                case ImmaterialResourceManager.Resource.PostService:
                    return 100;
                case ImmaterialResourceManager.Resource.None:
                    return 0;
                default:
                    return 0;
            }
        }

        public static int GetMaxEffect(ushort buildingId, ref Building building, ZonedBuildingExtenderPanel.LevelUpResource resource)
        {
            switch (resource)
            {
                case ZonedBuildingExtenderPanel.LevelUpResource.Education:
                    return 15;
                case ZonedBuildingExtenderPanel.LevelUpResource.Services:
                    return 15;
                default:
                    return 0;
            }
        }
    }
}
