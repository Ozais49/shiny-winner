using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using NLog.Config;
using NLog.Targets;
namespace LanguageNew.DAL
{
    public class NlogerConfig
    {
        public NlogerConfig()
        {
            var config = new LoggingConfiguration();
            var filetarget = new FileTarget("filetarget")
            {
                FileName = "${basedir}/ErrorLog/ErrorLog ${shortdate}.txt",
                Layout = @"${longdate} ${newLine} ${level} ${newline} Exception ${exception} ${newline} Message ${message} ${newline} ${StackTrace} ${newline}"

            };
            filetarget.ArchiveEvery = FileArchivePeriod.Day;
            filetarget.ArchiveFileName = "${basedir}/LogArchive/${shortdate}/ErrorlogArchive.{#}.log";
            filetarget.ArchiveNumbering = ArchiveNumberingMode.DateAndSequence;
            filetarget.CreateDirs = true;
            filetarget.ConcurrentWrites = true;
            filetarget.OpenFileCacheTimeout = 30;
            filetarget.ArchiveAboveSize = 10240;
            config.AddTarget(filetarget);
            config.AddRuleForOneLevel(LogLevel.Error, filetarget);
            LogManager.Configuration = config;
        }
    }
}
  