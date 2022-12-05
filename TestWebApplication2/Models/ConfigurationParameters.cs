/***********************************
** ConfigurationParameters.cs
** Author: Pooja Prasanna Nanjunda
** Email: poojananjunda1996@gmail.com
** Date: 04-12-2022
***********************************/

namespace TestWebApplication2.Models
{
    /// <summary>
    /// This class has configuration parameters.
    /// </summary>
    public class ConfigurationParameters
    {
        /// <summary>
        /// Gets or sets a value indicating whether the execution mode is through docker or not.
        /// </summary>
        public bool Dockerized { get; set; }

        /// <summary>
        /// Gets or sets the DatabasePath.
        /// </summary>
        public string? DatabasePath { get; set; }
    }
}
