if GetFlagInt("十字针之谜") == 1 then goto label0 end;
    Talk(110, "少侠，有打听到莫师父的死因吗？");
    Talk(0, "你问我？");
    Talk(110, "……啊？");
    Talk(0, "我是说……你问我……就问对了，我有个外号叫“渡城小仁杰”，我一定会想办法调查出真相，然后报告张大侠，到时候你就可以去给莫掌门报仇了。");
    Talk(110, "那就拜托了！");
    Talk(100, "这个大徒弟……就完全没有自己去调查的想法吗？");
    do return end;
::label0::
    Talk(110, "少侠，有打听到莫师父的死因吗？");
    Talk(0, "我已经知道凶手是谁了。");
    Talk(110, "什么？是谁干的？");
    Talk(0, "是渡城身份地位最高的人。");
    Talk(110, "王远？");
    Talk(0, "是的，他故意杀害莫掌门，意在削弱江湖门派的势力，巩固自己在渡城的地位。");
    Talk(110, "怎么会这样？");
    Talk(0, "我就是来找你一起去报仇的。");
    Talk(110, "王远将军毕竟是渡城的镇城之魂，我们还是不要轻举妄动。");
    Talk(0, "得了得了，我自己去。");
do return end;
