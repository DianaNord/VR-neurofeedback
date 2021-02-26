import random


def create_sequence(trials, tasks):

    sequence = []

    for t in range(trials):
        for i in range(len(tasks)):
            sequence.append(tasks[i])

    random.shuffle(sequence)
    return sequence


tasks_MI = ["MI_r", "MI_l"]  # MI left and right hand
tasks_ME = ["ME_r", "ME_l"]  # ME left and right hand
N_trials = 20                # trials per task
N_runs = 2                   # number of runs

for r in range(N_runs):
    sequence_MI = create_sequence(N_trials, tasks_MI)
    sequence_ME = create_sequence(N_trials, tasks_ME)

    file_object = open("MI_run_"+str(r+1)+".txt", "w")
    for trial in sequence_MI:
        file_object.write(trial+"\n")

    file_object = open("ME_run_"+str(r+1)+".txt", "w")
    for trial in sequence_ME:
        file_object.write(trial+"\n")

