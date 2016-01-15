# ATTSE

ATTSE(Automatic Test Tool for Screen Events) 是一个简单的屏幕录制工具，主要用于前端相关的自动化测试。

本项目参考自[搜狗公司](https://github.com/sogou)的[Test-ClickPrograme](https://github.com/sogou/Test-ClickPrograme)项目，并使用 `WPF` + `.Net Framework 3.5` 重新进行了构建，支持 Windows XP 及以上系统。

![Interface](https://raw.githubusercontent.com/2079/ATTSE/master/images/interface.png)

> 界面说明
- A: 屏幕事件列表
- B: 屏幕事件属性
- C: 操作配置

---

## 使用说明

1. 将鼠标移动到需要录制的位置

2. 按 `Ctrl + T` 键保存鼠标位置

3. 重复上述两个步骤直到记录好所有的位置

4. 点击事件列表中每个具体的事件编辑事件属性，可编辑项包括：
    - 事件类型（暂时只支持鼠标事件，后续会加入键盘操作事件）
    - 动作类型（左键单击/左键双击/右键单击/右键双击）
    - 延时时间（该事件动作的执行时间）
    - 执行次数（该事件动作在一次循环中的执行次数）

5. 在事件列表中选择事件，并点击删除按钮删除列表中不需要的屏幕事件

6. 设置循环次数（即列表中所有事件的执行次数）

7. 点击开始按钮启动屏幕事件过程。

## 拟增加特性

- **键盘输入事件**
- 事件列表停止功能
- 批量删除/移动事件
- 本地导入/导出事件列表
- 使用帮助
- 全局坐标显示