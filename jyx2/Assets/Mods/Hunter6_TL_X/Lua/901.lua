Talk(0, "小和尚，借个位。。。");
Talk(49, "佛观一钵水，四万八千虫，若不持此咒，如食众生肉，。你复习波罗模拟沙盒。");
Talk(0, "小师傅，你叽里咕噜念什么咒语啊？");
Talk(49, "小僧念的是饮水咒。佛曰每一碗水中，有八万四千条小虫，出家人戒杀，因此要念了饮水咒，这才喝得。。。。");
Talk(0, "这水干净得很，一条虫子也没有，小师傅真会说笑。");
-- if AskJoin() == true then goto label0 end;
--     Talk(0, "朱兄，我们还是各自去找线索，到时候再一起交流。");
--     do return end;
-- ::label0::
--     if TeamIsFull() == false then goto label1 end;
--         Talk(11, "你的队伍已满，我无法加入。");
--         do return end;
-- ::label1::
--     Talk(100, "这家伙虽然脑袋不好用，但是好歹也多个帮手。");
--     Talk(0, "好啊，求之不得，我们一起去探寻真相吧。");
--     DarkScence();
--     jyx2_ReplaceSceneObject("", "NPC/朱云天", "");
--     LightScence();
--     Join(11);
--     ModifyEvent(-2, -2, -2, -2, -1, -1, -1, -2, -2, -2, -2, -2, -2);
-- do return end;

if AskJoin() then
	if TeamIsFull()==false then
		Talk(0, "好啊，求之不得，我们一起去探寻真相吧。")
		DarkScence()
		jyx2_ReplaceSceneObject("", "NPC/虚竹", "")
		LightScence()
		Join(49)
		ModifyEvent(-2, -2, -2, -2, -1, -1, -1, -2, -2, -2, -2, -2, -2);
		do return end;
	else
		Talk(49,"你的队伍已满，我无法加入。")
		do return end;
	end
else
	Talk(0,"小和尚，突然忘了妈妈喊我回去吃饭，等我吃完饭再带你。")
	do return end;
end