using System.Collections;
using UnityEngine;
using HutongGames.PlayMaker;

public class CoroutineAction : FsmStateAction
{
    [RequiredField]
    public FsmFloat time;

    private Coroutine routine;

    public override void Reset()
    {
        time = 5f;
    }

    public override void OnEnter()
    {
        routine = StartCoroutine(DoWait());
    }

    private IEnumerator DoWait()
    {
        yield return new WaitForSeconds(time.Value);
        Finish();
    }

    public override void OnExit()
    {
        StopCoroutine(routine);
    }
}
