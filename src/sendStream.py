from pylsl import StreamInfo, StreamOutlet, cf_string
import random
import time


def create_stream_info_outlet():

    print('Creating a stream info')
    info_ = StreamInfo('Feedback', 'Markers', 2, 0, cf_string, 'myuid1234')
    print('Opening an outlet')
    outlet_ = StreamOutlet(info_)
    return outlet_


def create_paradigm(class_labels, trials):

    total_trials = len(class_labels) * trials
    random_labels = []

    for t in range(int(total_trials/2)):
        for lab in range(len(class_labels)):
            random_labels.append(class_labels[lab])

    random.shuffle(random_labels)

    return random_labels


def random_feedback(class_labels, trials):

    total_trials = len(class_labels) * trials
    random_labels = []

    for t in range(int(total_trials/2)):
        for lab in range(len(class_labels)):
            random_labels.append(class_labels[lab])

    random.shuffle(random_labels)

    return random_labels


def send_data(outlet_, labels_, feedback_):

    print("now sending markers...")
    for trial in range(len(labels_)):
        print([labels_[trial], feedback_[trial]])
        outlet_.push_sample([labels_[trial], feedback_[trial]])
        time.sleep(random.random() * 5)


# Create a paradigm

classes = ['right Hand', 'left Hand'] #task
trials_per_Label = 20
labels = create_paradigm(classes, trials_per_Label)

# Create feedback
feedback = random_feedback(classes, trials_per_Label)

# Stream paradigm and feedback
outlet = create_stream_info_outlet()
send_data(outlet, labels, feedback)
