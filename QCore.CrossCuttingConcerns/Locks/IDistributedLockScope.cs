using System;

namespace QCore.CrossCuttingConcerns.Locks;

public interface IDistributedLockScope : IDisposable
{
    bool StillHoldingLock();
}
