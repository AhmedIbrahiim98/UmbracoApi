using Microsoft.EntityFrameworkCore;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco_Api.Data;

namespace Umbraco_Api.NotificationHandler;

public class RunDBMigrations //: INotificationAsyncHandler<UmbracoApplicationStartingNotification>
{
    //private MyContext _context;

    //public RunDBMigrations(MyContext context)
    //{
    //    _context = context;
    //}

    //public async Task HandleAsync(UmbracoApplicationStartedNotification notification, CancellationToken cancellationToken)
    //{

    //    var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();

    //    if (pendingMigrations.Any())
    //    {
    //        _context.Database.MigrateAsync();
    //    }
    //}    //private MyContext _context;

    //public RunDBMigrations(MyContext context)
    //{
    //    _context = context;
    //}

    //public async Task HandleAsync(UmbracoApplicationStartedNotification notification, CancellationToken cancellationToken)
    //{

    //    var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();

    //    if (pendingMigrations.Any())
    //    {
    //        _context.Database.MigrateAsync();
    //    }
    //}
}
