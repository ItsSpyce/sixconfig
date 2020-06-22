using SixConfig.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SixConfig.Services
{
  public class ProfileService
  {
    private static readonly Regex ID_REGEX = new Regex("^[A-Za-z0-9]{8,}-[A-Za-z0-9]{4,}-[A-Za-z0-9]{4,}-[A-Za-z0-9]{4,}-[A-Za-z0-9]{12,}$", RegexOptions.Compiled);

    public Task<IEnumerable<Profile>> GetProfilesAsync(string directory)
    {
      return new Task<IEnumerable<Profile>>(() =>
      {
        var dirs = Directory.EnumerateDirectories(directory).Where(dir => ID_REGEX.IsMatch(dir));
        var profiles = dirs.Select(id => new Profile(id));
        return profiles;
      });
    }
  }
}
