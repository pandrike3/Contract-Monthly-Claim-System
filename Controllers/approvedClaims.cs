var approvedClaims = context.Claims.Where(c => c.Status == "Approved").ToList();

